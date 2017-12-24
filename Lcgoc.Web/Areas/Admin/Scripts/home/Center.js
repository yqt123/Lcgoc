$(function () {
    var routeHelper = new RouteHelper();
    var hashController = routeHelper.HashController();
    routeHelper.Action(false, hashController.action, hashController.controller, hashController.area);
});