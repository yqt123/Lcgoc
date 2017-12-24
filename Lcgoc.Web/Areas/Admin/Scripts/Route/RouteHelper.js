var RouteHelper = function () {
    var routeHelper = new Object();
    routeHelper.url = "/";
    //地址跳转
    //addHash 是否增加锚点
    routeHelper.Redirect = function (addHash, url) {
        if (url) {
            routeHelper.url = url;
        }
        // 加载图标显示
        $('.preloader').show();
        try {
            $.ajax({
                // mimeType 一个mime类型用来覆盖XHR的 MIME类型。
                mimeType: 'text/html; charset=utf-8', // ! Need set mimeType only when run from local file 需要设置的文件类型只有当运行从本地文件
                url: url,
                type: 'GET',
                success: function (data) {
                    if (addHash)
                        routeHelper.ChangeURL();
                    // #ajax-content div显示返回的内容
                    $('#ajax-content').html(data);
                    // 加载图隐藏
                    $('.preloader').hide();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                },
                dataType: "html",//dataType设置返回值  "html": 返回纯文本 HTML 信息；包含的script标签会在插入dom时执行。
                async: true
            });
        } catch (e) { console.log(e.message); };
    };

    //控制器跳转
    //addHash 是否增加锚点
    routeHelper.Action = function (addHash, action, controller, area) {
        if (area)
            routeHelper.url += area + "/";
        if (controller)
            routeHelper.url += controller + "/";
        if (action)
            routeHelper.url += action;
        routeHelper.Redirect(addHash, routeHelper.url);
    };

    //修改当前地址
    routeHelper.ChangeURL = function () {
        try {
            var url = "";
            if (routeHelper.url.substr(0, 1) == "/") {
                url = routeHelper.url.substr(1, routeHelper.url.length - 1);
            }
            if (location.href.indexOf("#") >= 0) {
                url = location.href.substr(0, location.href.indexOf("#")) + "#" + url;
            }
            else { url = location.href + "#" + url; }
            window.history.pushState({}, 0, url);
        } catch (e) {
            console.log(e.message);
        }
    };

    //获取锚对应的控制器
    routeHelper.HashController = function () {
        var controller, action, area;
        if (location.hash) {
            var hash = location.hash.substr(1, location.hash.length - 1);
            var hashs = hash.split('/');
            switch (hashs.length) {
                case 0: controller = "/"; break;
                case 1: action = hashs[0]; break;
                case 2: controller = hashs[0]; action = hashs[1]; break;
                case 3: area = hashs[0]; controller = hashs[1]; action = hashs[2]; break;
            }
        }
        else { controller = "Home"; action = "Index"; area = "Admin"; }
        return { controller: controller, action: action, area: area };
    };
    return routeHelper;
};

(function () {
    // 记录到历史里，当点击后退按钮还退回上次页面请求前的页面内容
    window.onpopstate = function () {
        var routeHelper = new RouteHelper();
        var hashController = routeHelper.HashController();
        routeHelper.Action(false, hashController.action, hashController.controller, hashController.area);
    }
})();