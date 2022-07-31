$(document).on("click", ".ToCartButton", function () {
    var Id = $(this).val();
    console.log(Id);
    $.ajax({
        method: "POST",
        url: "/Home/AddToCart",
        data: {
            "Id": Id
        },
        success: function (data) {
            
            $("#Id").html(data)
        }
    })
})
$(document).on("click", ".itemCheckbox", function () {
    var Id = $(this).val();
    if ($(this).is(':checked')) {
        $.ajax({
            method: "POST",
            url: "/Home/AddCostsToBill",
            data: {
                "Id": Id
            },
            success: function (data) {

                $("#Id").html(data)
            }
        })
        $(".Payment").load("/Home/PartialBill");
    }
    else
    {
        $.ajax({
            method: "POST",
            url: "/Home/SubstractCostsFromBill",
            data: {
                "Id": Id
            },
            success: function (data) {

                $("#Id").html(data)

            }
        })
        $(".Payment").load('/Home/PartialBill');
    }
    
})

$(".FinalizeButton").click(function (e) {
   
    $.ajax({
        method: "GET",
        url: "/Home/FinalizeShopping",
        data: {
            
        },
        success: function (data) {

         
        }
    })
})

$(".sub").click(function (e) {
    e.preventDefault();
    
    if ($("#Email").val() != "" && $("#Password").val() != "")
    {
        $.ajax({
            method: "GET",
            url: "/Home/FinalizeShopping",
            data: {

            },
            success: function (data) {

                console.log("shit");
            }
        })
    }
})
$(".IncrementNumber").click(function () {
    var maxVal = $(".AmountOfNumbersInput").attr("max");
    var id = $(".invisible").attr("id");
        $.ajax({
            method: "POST",
            url: "/Home/IncrementNumberOfItemsTaken",
            data: {
                "id": id,
                "maxVal": maxVal
            },
            success: function (data) {
             
               
            }
        })
    $.ajax({
        method: "POST",
        url: "/Home/ItemAmountPartialView",
        data: {
            id:id
           
        },
        success: function (response) {
            $(".Amount").html(response);
          
        }
    })
    
    $.ajax({
        method: "POST",
        url: "/Home/PartialItemsTakenLabel",
        data: {
            id: id

        },
        success: function (response) {
            $(".itemsTaken").html(response);

        }
    })
})
$(".SubstractNumber").click(function () {
    var id = $(".invisible").attr("id");

    console.log(id);
        $.ajax({
            method: "POST",
            url: "/Home/SubstractFromNumberOfItemsTaken",
            data: {
                "id": id,
            },
            success: function (data) {

                
            }
        })
    
    
    $.ajax({
        method: "POST",
        url: "/Home/ItemAmountPartialView",
        data: {
            id: id

        },
        success: function (response) {
            $(".Amount").html(response);

        }
    })

    $.ajax({
        method: "POST",
        url: "/Home/PartialItemsTakenLabel",
        data: {
            id: id

        },
        success: function (response) {
            $(".itemsTaken").html(response);

        }
    })
   
        
})

$(".CategoryType").click(function (e) {
    e.preventDefault();
    var Category = $(this).text();
    $.ajax({

        method: "POST",
        url: "/Home/SearchForItemByCategory",
        data: {

            searchTerm: Category
        },
        success: function (response) {

            $().html(response);
        }
    })
})
$(document).on("click", ".ToCartButtonMany", function () {
    var Id = $(this).val();
    var amount = $(".AmountOfNumbersInput").val();
    console.log(Id);
    $.ajax({
        method: "POST",
        url: "/Home/AddToCartMany",
        data: {
            "Id": Id,
            "amount": amount
        },
        success: function (data) {

            $("#Id").html(data)
            
        }
    })
})










$(".IncrementNumberInCart").click(function () {
    var maxVal = $(".AmountOfNumbersInput").attr("max");
    var id = $(this).attr("id");
    
    
    $.ajax({
        method: "POST",
        url: "/Home/IncrementNumberOfItemsTaken",
        data: {
            "id": id,
            "maxVal": maxVal
        },
        success: function (data) {


        }
    })
    $.ajax({
        method: "POST",
        url: "/Home/ItemAmountPartialView",
        data: {
            id: id

        },
        success: function (response) {
            $(".Amount." + id).html(response);
            
        }
    })
    

    $.ajax({
        method: "POST",
        url: "/Home/PartialItemsTakenLabel",
        data: {
            id: id

        },
        success: function (response) {
            $(".itemsTaken." + id).html(response);

        }
    })
    $(".Payment").load("/Home/PartialBill");
})
$(".SubstractNumberInCart").click(function () {
   
    var id = $(this).attr("id");
    
    
    $.ajax({
        method: "POST",
        url: "/Home/SubstractFromNumberOfItemsTaken",
        data: {
            "id": id,
        },
        success: function (data) {


        }
    })


    $.ajax({
        method: "POST",
        url: "/Home/ItemAmountPartialView",
        data: {
            id: id

        },
        success: function (response) {
            $(".Amount." + id).html(response);

        }
    })

    $.ajax({
        method: "POST",
        url: "/Home/PartialItemsTakenLabel",
        data: {
            id: id

        },
        success: function (response) {
            $(".itemsTaken." + id).html(response);

        }
    })
    $(".Payment").load("/Home/PartialBill");

})


var el = document.getElementById("AmountOfNumbersInputId");
el.addEventListener('input', function moreThenTwo(e) {
    var value = $(this).val();
    var id = $(".invisible").attr("id");
    $.ajax({
        method: "POST",
        url: "/Home/DetectInputtedValue",
        data: {
            value: value,
            id:id
        },
        success: function (response) {
            
        }
    })
    $(".itemsTaken").html(response);

})