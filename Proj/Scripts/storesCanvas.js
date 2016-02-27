var dataResault2;

$(document).ready(function()
{
    console.log( "ready!" ); 
    var canvas = $("#myCanvas").get(0);
    var img = $("#shauliCanvasImage").get(0);
    var ctx = canvas.getContext("2d");
    ctx.drawImage(img, 10, 10);
    var img3 = $("#shauliCanvasImage3").get(0);
    ctx.drawImage(img3, 186, 10);
    var img2 = $("#shauliCanvasImage2").get(0);
    ctx.drawImage(img2, 362, 10);
    ctx.font = "40px Comic Sans MS";
    ctx.fillStyle = "Red";
    ctx.textAlign = "center";
    ctx.fillText("Our Gift Stores:", canvas.width / 2, canvas.height / 4);
});





