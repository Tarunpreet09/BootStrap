function Add(id) {

    window.location = "/Supplier/Index?Id=" + id;
    
}

$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Supplier/Reload",
        dataType:'JSON',
        success: function (res) {
            var template = $('#templatefile').html();
            Mustache.parse(template);
            var rendered = "";           
                $.each(res, function () {

                    rendered += Mustache.render(template, this)
                });
                $("#data").html(rendered);
        }
    })
})

function Save(id) {
   
    var obj = {};
    obj.Gid = id;
    obj.Supplier_Name = $('#Supplier_Name').val();
    obj.Mobile_No = $('#Mobile_No').val();
    obj.ZipCode = $('#ZipCode').val();
    obj.State = $('#State').val();
    obj.City = $('#City').val();
    obj.Email = $('#Email').val();

    obj.arr = [];
    $('.newdt').find("tr").forEach(function (a, b) {
        var Item_lst = {};
        Item_lst.Item_Name = $(b).find('#Item_Name').text();


    })

    $.ajax({
        type: "GET",
        url: "/Supplier/Resultdata",
        data: obj,
        dataType:"Json",
        success: function (res) {
            window.location = `/Supplier/tabledata`;
        }
        })

}



function Delete(d) {


    $.ajax({
        type: "get",
        url: "/Supplier/Del",
        data: { "guid": d },
        success: function (res) {
            window.location = "/Supplier/tabledata";
           

        }
    })
}


