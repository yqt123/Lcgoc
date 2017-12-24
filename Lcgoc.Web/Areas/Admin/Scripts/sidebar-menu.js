(function () {
    $('.treeview-menu').on('click', 'a', function (e) {
        if ($(this).hasClass('ajax-link')) {
            e.preventDefault();
            //点击 切换显示内容
            new RouteHelper().Redirect(true, $(this).attr('href'));
        }
    });
})();