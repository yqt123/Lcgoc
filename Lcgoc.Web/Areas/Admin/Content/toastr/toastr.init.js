﻿//初始化弹框窗口
(function ($T) {
    //参数设置，若用默认值可以省略以下面代
    $T.options = {

        "closeButton": false, //是否显示关闭按钮

        "debug": false, //是否使用debug模式

        "positionClass": "toast-center-center",//弹出窗的位置

        "showDuration": "300",//显示的动画时间

        "hideDuration": "1000",//消失的动画时间

        "timeOut": "3000", //展现时间

        "extendedTimeOut": "1000",//加长展示时间

        "showEasing": "swing",//显示时的动画缓冲方式

        "hideEasing": "linear",//消失时的动画缓冲方式

        "showMethod": "fadeIn",//显示时的动画方式

        "hideMethod": "fadeOut" //消失时的动画方式

    };

})(toastr);
