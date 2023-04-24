function AddData() {
    var obj = {};
    obj.subject = $('#subject').find(":selected").val();
    obj.marks = $("#marks").val(); 
    $.ajax({
        type: "POST",
        url: "/Home/data1",
        data: obj,
        success: function (res) {
            var t;
            $("#data").html(" ");
            res.forEach(function (value) {
                t = `<tr id="${value.guid}">
                 <td>${value.subject}</td>
                 <td>${value.marks}</td>
                 <td>
                 <button onclick="Edit('${value.guid}')"class="btn btn-primary">Edit</button>
                 <button onclick="Del('${value.guid}')"class="btn btn-danger">Delete</button>
                 </td>
                 </tr>`
                $('#data').append(t);
            })
        }
    })
}


function Del(d) {
    $.ajax({
        type: "POST",
        url: "/Home/Del",
        data: { guid: d },
        success: function (res) {
            $("#data").html(" ");
            res.forEach(function (value) {
                var t = `<tr id="${value.guid}">
                 <td>${value.subject}</td>
                 <td>${value.marks}</td>               
                 <td>
                 <button onclick="Edit('${value.guid}')"class="btn btn-primary">Edit</button>
                 <button onclick="Del('${value.guid}')"class="btn btn-danger">Delete</button>
                 </td>
                 </tr>`
                $('#data').append(t);
            })
        }
    })
}

function Edit(a) { 
    $('#hiddenval').val(a);
    $('#myModal2').modal("show");
}

function Update() {
    var model = $("#hiddenval").val()
    var obj = {};
    obj.subject = $('#subject1').val();   
    obj.marks = $("#marks1").val();
    alert(obj.marks);
    $.ajax({
        type: "POST",
        url: "/Home/Edit1",
        data: { "ID": model, "first": obj },
        success: function (res) {
            $("#data").html(" ");
            res.forEach(function (value) {
                var t =`<tr id="${value.guid}">
                     <td>${value.subject}</td>
                     <td>${value.marks}</td>
                     <td>
                     <button onclick="Edit('${value.guid}')"class="btn btn-primary">Edit</button>
                     <button onclick="Del('${value.guid}')"class="btn btn-danger">Delete</button>
                     </td>
                     </tr>`             
                $('#data').append(t);              
            })
        }
    })
}
