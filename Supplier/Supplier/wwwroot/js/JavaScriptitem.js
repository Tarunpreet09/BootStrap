function Add(id) {
    window.location = "/Items/red?id=" + id ;
}


$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Items/Reload",
        dataType: 'JSON',
        success: function (res) {
            var template = $('.templatefile123').html();
            Mustache.parse(template);
            var rendered = "";


            $.each(res, function () {

                rendered += Mustache.render(template, this)
            });
            $(".data123").html(rendered);
        }
    })
})

function Save(id) {
    
    var obj1 = {};
    obj1.Gi = id;
    obj1.Item_Name = $('#Item_Name').val();
    obj1.Notes = $('#Notes').val();
    

    $.ajax({
        type: "GET",
        url: "/Items/View_Item",
        data: obj1,
        dataType: "Json",
        success: function (res) {
            window.location = `/Items/Item1`;
        }
        })
}

function Delete(d) {
    $.ajax({
        type: "get",
        url: "/Items/Del",
        data: { "guid": d },
        success: function (res) {
            window.location = "/Items/Item1";


        }
    })
}


var a1, a2;
function check(x) {
    var t;
    a1 = $(x).next().val();
    a2 = $(x).next().next().val();
    t = `<tr><td>${a1}</td><td>${a2}</td></tr>`
    $('.newdt').append(t);



}

