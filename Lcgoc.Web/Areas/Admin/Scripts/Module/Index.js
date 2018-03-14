/// <reference path="../../../../Scripts/jquery-1.9.1.min.js" />
/*
tableId:表格ID
tableQueryActionUrl:查询方法地址
minimumCountColumns:最小显示行
height:表格高
columns:表格显示的行
queryParams:查询方法
*/
var TableInit = function (tableId, tableQueryActionUrl, minimumCountColumns, height, columns, queryParams) {
    var oTableInit = new Object();
    //得到查询的参数
    oTableInit.queryParams = queryParams;
    //初始化Table
    oTableInit.Init = function () {
        $('#' + tableId).bootstrapTable({
            url: tableQueryActionUrl,         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: false,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            search: true,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
            strictSearch: true,
            showColumns: true,                  //是否显示所有的列
            showRefresh: true,                  //是否显示刷新按钮
            minimumCountColumns: minimumCountColumns,             //最少允许的列数
            clickToSelect: true,                //是否启用点击选中行
            height: height,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            //uniqueId: "code",                   //每一行的唯一标识，一般为主键列
            showToggle: true,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: false,                  //是否显示父子表
            columns: columns
        });
    };
    //声明时执行一次初始化
    oTableInit.Init();
    return oTableInit;
};

var ButtonInit = function () {
    var oInit = new Object();
    var postdata = {};

    oInit.Init = function () {
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
            postdata.ids = "";
            var n = 0;
            $(arrselections).each(function (i, item) {
                if (n == 0) {
                    postdata.ids += item.code;
                }
                else {
                    postdata.ids += "," + item.code;
                }
                n++;
            });
            Ewin.confirm({ message: "确认要删除选择的数据吗？" }).on(function (e) {
                if (!e) {
                    return;
                }
                $.ajax({
                    type: "post",
                    url: "/Admin/Menu/Delete",
                    data: postdata,
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
            postdata.code = $("#code").val();
            postdata.icon = $("#icon").val();
            postdata.name = $("#name").val();
            postdata.allowused = $("#allowused").val();
            postdata.level = $("#level").val();
            postdata.pullRightContainer = $("#pullRightContainer").val();

            $.ajax({
                type: "post",
                //dataType: "json",
                url: "/Admin/Menu/CreateEdit",
                data: postdata,//JSON.stringify(postdata),
                success: function (data, status) {
                    if (data.Status) {
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