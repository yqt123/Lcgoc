﻿var RouteHelper = function () {
    var routeHelper = new Object();
    routeHelper.Action = function (controller, action, area) {
        var _url = "";
        if (area)
            _url += area + "/";
        if (controller)
            _url += controller + "/";
        if (action)
            _url += action;
        // 加载图标显示
        $('.preloader').show();
        $.ajax({
            // mimeType 一个mime类型用来覆盖XHR的 MIME类型。
            mimeType: 'text/html; charset=utf-8', // ! Need set mimeType only when run from local file 需要设置的文件类型只有当运行从本地文件
            url: _url,
            type: 'GET',
            success: function (data) {
                // #ajax-content div显示返回的内容
                $('#ajax-content').html(data);
                // 加载图隐藏
                $('.preloader').hide();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            },
            dataType: "html",//dataType设置返回值  "html": 返回纯文本 HTML 信息；包含的script标签会在插入dom时执行。
            async: false
        });
    };
    return routeHelper;
};