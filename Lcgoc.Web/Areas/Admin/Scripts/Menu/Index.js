
$(function () {

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    //2.初始化Button的点击事件
    var oButtonInit = new ButtonInit();
    oButtonInit.Init();

    var oToastrInit = new ToastrInit();
    oToastrInit.Init();
});

var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#tb_departments').bootstrapTable({
            url: '/Admin/Menu/GetMenus',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber:1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            search: true,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
            strictSearch: true,
            showColumns: true,                  //是否显示所有的列
            showRefresh: true,                  //是否显示刷新按钮
            minimumCountColumns: 2,             //最少允许的列数
            clickToSelect: true,                //是否启用点击选中行
            height: 500,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: "code",                   //每一行的唯一标识，一般为主键列
            showToggle:true,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: false,                  //是否显示父子表
            columns: [{
                checkbox: true
            }, {
                field: 'code',
                title: '菜单编码'
            }, {
                field: 'icon',
                title: '标题图标'
            }, {
                field: 'name',
                title: '标题名称'
            }, {
                field: 'allowused',
                title: '是否可用'
            }, {
                field: 'modifyDTM',
                title: '创建时间'
            }, {
                field: 'level',
                title: '排序'
            }, {
                field: 'pullRightContainer',
                title: '标题栏数字'
            },
            ]
        });
    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            pageSize: params.limit,   //页面大小
            pageIndex: params.offset,  //页码
            code: $("#txt_search_code").val(),
            name: $("#txt_search_name").val()
        };
        return temp;
    };
    return oTableInit;
};

var ButtonInit = function () {
    var oInit = new Object();
    var postdata = {};
    var headers = {};

    oInit.Init = function () {
        //防伪标记放入headers
        //也可以将防伪标记放入data
        headers["__RequestVerificationToken"] = $('input[name=__RequestVerificationToken]').val();

        $("#btn_add").click(function () {
            $("#myModalLabel").text("新增");
            $("#myModal").find(".form-control").val("");
            $('#myModal').modal()
            postdata.code = "";
        });

        $("#btn_edit").click(function () {
            var arrselections = $("#tb_departments").bootstrapTable('getSelections');
            if (arrselections.length > 1) {
                toastr.warning('只能选择一行进行编辑');

                return;
            }
            if (arrselections.length <= 0) {
                toastr.warning('请选择有效数据');

                return;
            }
            $("#myModalLabel").text("编辑");
            $("#code").val(arrselections[0].code);
            $("#icon").val(arrselections[0].icon);
            $("#name").val(arrselections[0].name);
            $("#allowused").val(arrselections[0].allowused);
            $("#level").val(arrselections[0].level);
            $("#pullRightContainer").val(arrselections[0].pullRightContainer);
            postdata.code = arrselections[0].code;
            $('#myModal').modal();
        });

        $("#btn_delete").click(function () {
            var arrselections = $("#tb_departments").bootstrapTable('getSelections');
            if (arrselections.length <= 0) {
                toastr.warning('请选择有效数据');
                return;
            }

            Ewin.confirm({ message: "确认要删除选择的数据吗？" }).on(function (e) {
                if (!e) {
                    return;
                }
                $.ajax({
                    type: "post",
                    url: "/Admin/Menu/Delete",
                    headers: headers,
                    data: JSON.stringify(arrselections),
                    success: function (data, status) {
                        if (status == "success") {
                            toastr.success('提交数据成功');
                            $("#tb_departments").bootstrapTable('refresh');
                        }
                    },
                    error: function () {
                        toastr.error('Error');
                    },
                    complete: function () {

                    }
                });
            });
        });

        $("#btn_submit").click(function () {
            postdata.icon = $("#icon").val();
            postdata.name = $("#name").val();
            postdata.allowused = $("#allowused").val();
            postdata.level = $("#level").val();
            postdata.pullRightContainer = $("#pullRightContainer").val();

            $.ajax({
                type: "post",
                url: "/Admin/Menu/GetEdit",
                headers: headers,
                data: JSON.stringify(postdata),
                success: function (data, status) {
                    if (status == "success") {
                        toastr.success('提交数据成功');
                        $("#tb_departments").bootstrapTable('refresh');
                    }
                },
                error: function () {
                    toastr.error('Error');
                },
                complete: function () {

                }
            });
        });

        $("#btn_query").click(function () {
            $("#tb_departments").bootstrapTable('refresh');
        });
    };

    return oInit;
};

var ToastrInit = function () {

    var oInit = new Object();
    oInit.Init=function(){

        //参数设置，若用默认值可以省略以下面代

        toastr.options = {

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
    };

    return oInit;
};