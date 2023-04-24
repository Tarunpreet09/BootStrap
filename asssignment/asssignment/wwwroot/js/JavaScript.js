$(document).ready(function () {    
    $.ajax({
        type: "GET",
        url: "/Home/Reload",
        datatype: "JSON",
        success: function (res) {           
             append(res)
        }
    });
})

function append(res) {
    var t;
    res.forEach(function(value) {
        t = `<tr id="${value.guid}">
                 <td id="sub_${value.guid}">${value.subject}</td>
                 <td id="mark_${value.guid}">${value.marks}</td>
                 <td>
                 <button onclick="Edit('${value.guid}')"class="btn btn-primary">Edit</button>
                 <button onclick="Del('${value.guid}')"class="btn btn-danger">Delete</button>
                 </td>
                 </tr>`
        $('#data').append(t);
    })
}

function AddData() {
    var obj = {};
    obj.subject = $('#subject').find(":selected").val();
    obj.marks = $("#marks").val();
    $.ajax({
        type: "POST",
        url: "/Home/data1",
        data: obj,
        dataType: "JSON",
        success: function (res) {
            $('#data').html("");
            append(res);
        }
    })
    $("#marks").val("");
    $("#subject").val("");
}

function Del(d) {
    $.ajax({
        type: "POST",
        url: "/Home/Del",
        data: { guid: d },       
        success: function (res) {
            window.location = "/Home/data";            
        }
    })
}

function Edit(a) {
    $('#hiddenval').val(a);
    $('#myModal2').modal("show");

    var r = $("#sub_" + a).html();
    var s = $("#mark_" + a).html();
    $("#subject1").val(r);
    $("#marks1").val(s);
}

function Update() {
    var model = $("#hiddenval").val();
    var obj = {};
    obj.subject = $('#subject1').val();
    obj.marks = $("#marks1").val();
    $.ajax({
        type: "POST",
        url: "/Home/Edit1",
        data: { "guid": model, "first": obj },        
        success: function (res) {           
            window.location =  "/Home/data";
        }
    })
}
