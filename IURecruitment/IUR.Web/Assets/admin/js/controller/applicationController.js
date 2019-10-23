var sortItem = null;
var applicationController = {
    init: function () {
        applicationController.loadApplications(sortItem);
        applicationController.registerEvent();
    },

    registerEvent: function () {
        $('#btnFullname').off('click').on('click', function (e) {
            e.preventDefault();
            sortItem = "fullname";
            applicationController.loadApplications(sortItem);
        });
        $('#btnDepartment').off('click').on('click', function (e) {
            e.preventDefault();
            sortItem = "department";
            applicationController.loadApplications(sortItem);
        });
        $('#btnPosition').off('click').on('click', function (e) {
            e.preventDefault();
            sortItem = "position";
            applicationController.loadApplications(sortItem);
        });

        $('#btnDeleteAll').off('click').on('click', function (e) {
            e.preventDefault();
            bootbox.confirm("Are you sure to delete these applicants?", function (result) {
                if (result) {
                    var listId = "";
                    $.each($('.chkDelete'), function (i, item) {
                        if ($(this).prop('checked')) {
                            listId = listId + $(this).data("id") + "-";
                        }
                    });
                    $.ajax({
                        url: "/Admin/Application/DeleteAll",
                        data: { listId: JSON.stringify(listId) },
                        dataType: "json",
                        type: "POST",
                        success: function (response) {
                            if (response.status === true) {
                                toastr.success(response.message);
                                applicationController.loadApplications();
                                applicationController.registerEvent();
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
            var applicantId = $(this).data("id");
            var jobId = $(this).data("jobid");
            bootbox.confirm("Are you sure to delete this?", function (result) {
                if (result) {
                    applicationController.deleteApplication(applicantId, jobId);
                }
            });
        });
    },
    deleteApplication: function (applicantId, jobId) {
        $.ajax({
            url: '/Admin/Application/Delete',
            type: 'POST',
            dataType: 'json',
            data: {
                id: applicantId
            },
            success: function (response) {
                if (response.status) {
                    toastr.success(response.message);
                    applicationController.loadApplications();
                    applicationController.registerEvent();
                }
                else {
                    toastr.error("Delete failed");
                    applicationController.registerEvent();
                }
            }
        });
    },

    loadApplications: function (sortItem) {
        $.ajax({
            url: '/Admin/Application/LoadApplications',
            type: 'GET',
            dataType: 'json',
            data: { sortItem: sortItem },
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            Index: i + 1,
                            ID: item.ApplicantID,                            
                            Fullname: item.Fullname,
                            Department: item.Department,
                            AppliedPosition: item.Position,
                            DateApplied: item.AppliedDate,
                            ResumeURL: '<a href="'+item.ResumeURL+'" target="_blank">View</a>'
                        });
                    });
                    $("#tblApplicants").html(html);
                    applicationController.registerEvent();
                }
            }
        });
    }
};

applicationController.init();