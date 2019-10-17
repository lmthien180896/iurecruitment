var controlConfig = {
    pageIndex: 1,
    pageSize: 10
};
var jobController = {
    init: function () {
        jobController.loadJobs();
        jobController.registerEvent();
    },

    registerEvent: function () {
        $('#btnDepartment').off('click').on('click', function (e) {
            e.preventDefault();
            var sortItem = "department";
            $('#txtSortItem').val("department");
            jobController.loadJobs(sortItem);
        });
        $('#btnPosition').off('click').on('click', function (e) {
            e.preventDefault();
            var sortItem = "position";
            $('#txtSortItem').val("position");
            jobController.loadJobs(sortItem);
        });
        $('#btnPostedDate').off('click').on('click', function (e) {
            e.preventDefault();
            var sortItem = "posteddate";
            $('#txtSortItem').val("posteddate");
            jobController.loadJobs(sortItem);
        });

        $('.btnUpdate').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            $('#modalAddUpdate').modal('show');
            jobController.GetJobDetail(id);
        });

        $('.btnStatus').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = $(this).data("id");
            $.ajax({
                url: '/Admin/Job/ChangeStatus',
                type: 'POST',
                dataType: 'json',
                data: { id: id },
                success: function (response) {
                    if (response.status) {
                        btn.text('Activated');
                        btn.removeClass('badge-danger');
                        btn.addClass('badge-success');
                        toastr.success("Activated " + response.data);
                    }
                    else {
                        btn.text('Disabled');
                        btn.addClass('badge-danger');
                        btn.removeClass('badge-success');
                        toastr.warning("Disable " + response.data);
                    }
                }
            });
        });


        $('#btnAdd').off('click').on('click', function (e) {
            e.preventDefault();
            $('#modalAddUpdate').modal('show');
            jobController.clearForm();
        });

        $('#btnSave').off('click').on('click', function () {
            jobController.saveData();
        });

        $('#btnDeleteAll').off('click').on('click', function (e) {
            e.preventDefault();
            bootbox.confirm("Are you sure to delete these jobs?", function (result) {
                if (result) {
                    var listId = "";
                    $.each($('.chkDelete'), function (i, item) {
                        if ($(this).prop('checked')) {
                            listId = listId + $(this).data("id") + "-";
                        }
                    });
                    $.ajax({
                        url: "/Admin/Job/DeleteAll",
                        data: { listId: JSON.stringify(listId) },
                        dataType: "json",
                        type: "POST",
                        success: function (response) {
                            if (response.status === true) {
                                toastr.success(response.message);
                                jobController.loadJobs();
                                jobController.registerEvent();
                            }
                            else {
                                console(response.message);
                            }
                        }
                    });
                }
            });
        });

        $('.btnDelete').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = $(this).data("id");
            var sortItem = $('#txtSortItem').val();
            bootbox.confirm("Are you sure to delete this job?", function (result) {
                if (result) {
                    $.ajax({
                        url: '/Admin/Job/Delete',
                        type: 'POST',
                        dataType: 'json',
                        data: { id: id },
                        success: function (response) {
                            if (response.status) {
                                toastr.success(response.message);
                                jobController.loadJobs(sortItem);
                                jobController.registerEvent();
                            }
                            else {
                                toastr.error(response.message);
                                jobController.loadJobs(sortItem);
                                jobController.registerEvent();
                            }
                        }
                    });
                }
            });
        });
    },

    saveData: function () {
        var isvalidated = false;
        var id = $('#txtID').val();
        var employeetype = $('#sltEmployeeType').val();
        var status = $('#chkStatus').prop("checked");
        var timetype = $('#sltTimeType').val();
        var jobtitle = $('#txtJobTitle').val();
        if (jobtitle == null || jobtitle == "") {
            bootbox.alert("Please enter job title.");
            $('#txtJobTitle').addClass("invalidate-input");
            $('#txtJobTitle').focus();
            isvalidated = false;
        }
        else {
            var departmentId = $('#sltDepartment').val();
            if (departmentId == "") {
                bootbox.alert("Please choose a department.");
                $('#sltDepartment').addClass("invalidate-input");
                $('#sltDepartment').focus();
                isvalidated = false;
            }
            else {
                var deadline = $('#txtDeadline').val();
                if (deadline == "") {
                    bootbox.alert("Please choose a deadline.");
                    $('#txtDeadline').addClass("invalidate-input");
                    $('#txtDeadline').focus();
                    isvalidated = false;
                }
                else {
                    txtDescription.updateElement();
                    var description = $('#txtJobDescription').val();
                    if (description == "") {
                        bootbox.alert("Please enter job description.");
                        isvalidated = false;
                    }
                    else {
                        txtRequirement.updateElement();
                        var requirement = $('#txtRequirement').val();
                        if (requirement == "") {
                            bootbox.alert("Please enter job requirements.");
                            isvalidated = false;
                        }
                        else
                            isvalidated = true;
                    }
                }
            }
        }
        if (isvalidated) {
            var job = {
                ID: id,
                Name: jobtitle,
                EmployeeType: employeetype,
                TimeType: timetype,
                DepartmentID: departmentId,
                Deadline: deadline,
                Description: description,
                Requirement: requirement,
                Status: status
            };
            $.ajax({
                url: '/Admin/Job/AddOrUpdate',
                data: { model: JSON.stringify(job) },
                type: 'POST',
                dataType: 'json',
                success: function (response) {
                    if (response.status == true) {
                        toastr.success(response.message);
                        $('#modalAddUpdate').modal('hide');
                        var sortItem = $('#txtSortItem').val();
                        jobController.loadJobs(sortItem);
                    }
                    else {
                        toastr.error(response.message);
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
    },

    GetJobDetail: function (id) {
        $.ajax({
            url: '/Admin/Job/GetJobDetail',
            type: 'GET',
            dataType: 'json',
            data: { id: id },
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    $('#txtID').val(data.ID);
                    $('#chkStatus').prop("checked", data.Status);
                    $('#txtJobTitle').val(data.Name);
                    $('#sltEmployeeType').val(data.EmployeeType);
                    $('#sltTimeType').val(data.TimeType);
                    $('#sltDepartment').val(data.Department.ID);
                    $('#txtDeadline').val(data.DeadlineDate);
                    $('#txtJobDescription').val(data.Description);
                    $('#txtRequirement').val(data.Requirement);
                    txtDescription.setData(data.Description);
                    txtRequirement.setData(data.Requirement);
                    jobController.registerEvent();
                }
            }
        });
    },

    clearForm: function () {
        $('#txtID').val(0);
        $('#txtJobTitle').val("");
        $('#stEmployeeType').val("Staff");
        $('#sltTimeType').val("Full-time");
        $('#sltDepartment').val("");
        $('#txtDeadline').val("");
        txtDescription.setData("");
        txtRequirement.setData("");
    },

    loadJobs: function (sortItem) {
        $.ajax({
            url: '/Admin/Job/LoadJobs',
            type: 'GET',
            dataType: 'json',
            data: {
                sortItem: sortItem,
                page: controlConfig.pageIndex,
                pageSize: controlConfig.pageSize
            },
            success: function (response) {
                if (response.status) {
                    if (response.totalRow > 0) {
                        var data = response.data;
                        var html = '';
                        var template = $('#template').html();
                        $.each(data, function (i, item) {
                            html += Mustache.render(template, {
                                Index: i + 1,
                                ID: item.ID,
                                Department: item.Department.Name,
                                Position: item.Name,
                                PostedDate: item.PostedDate,
                                Deadline: item.DeadlineDate,
                                Status: item.Status == true ? '<a href="#" class="badge badge-success btnStatus" data-id="' + item.ID + '">Activated</a>' : '<a href="#" class="badge badge-danger btnStatus" data-id="' + item.ID + '">Disabled</a>'
                            });
                        });
                        $("#tblJobs").html(html);
                        jobController.paging(response.totalRow, function () {
                            var sortItem = $('#txtSortItem').val();
                            jobController.loadJobs(sortItem);
                        });
                        jobController.registerEvent();
                    }
                    else {
                        $("#tblJobs").html("<td colspan='8'>No data to display</td>");
                    }
                }
            }
        });
    },

    paging: function (totalRow, callback) {
        var totalPage = Math.ceil(totalRow / controlConfig.pageSize);
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            visiblePages: 10,
            onPageClick: function (event, page) {
                controlConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
};

jobController.init();