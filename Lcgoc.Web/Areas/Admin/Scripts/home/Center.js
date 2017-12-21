$(function () {
    var center = new CenterObj();
    center.init();
});

var CenterObj = function () {
    var centerObj = new Object();
    centerObj.init = function () {
        var controller, action, area;
        if (location.hash) {
            var hash = location.hash.substr(1, location.hash.length - 1);
            var hashs = hash.split('/');
            switch (hashs.length) {
                case 0: controller = "/"; break;
                case 1: controller = hashs[0]; break;
                case 2: controller = hashs[0]; action = hashs[1]; break;
                case 3: controller = hashs[0]; action = hashs[1]; area = hashs[2]; break;
            }
        }
        else { controller = "Home"; action = "Index"; area = "Admin"; }
        new RouteHelper().Action(action, controller, area);
    };
    return centerObj;
};
