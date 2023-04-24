var arr = [];

function fun()

{
    
    var abc = $('#txt').val();
    $.ajax({
        type: "Get",
        url: "https://api.instantwebtools.net/v1/airlines",
        datatype: "json",
        success: function (resy) {
          
            alert("ewdfwf");
            resy.forEach(function (value, index, array) {
                
                if (value.country == "India" || value.country=="india")
                {
                    arr.push(value);
                }

            })
           
            arr.forEach(function (value, index, array) {

                var st = `<tr>
                            <td>${value.id}</td>
                           <td>${value.name}</td>
                           <td>${value.country}</td>
                         </tr>`
                $("#pp").append(st);
            })
           
        }
        })
}