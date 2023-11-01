/*
var wheelSpin = document.getElementById("wheelSpin");
var btnWS = document.getElementById("btnWS");

btnWS.onclick = function() {
    wheelSpin.style.animationPlayState = "running";
    wheelSpin.style.display = "block";
}
*/


function myfunction() {
    var x = 1024;
    var y = 9999;
    var deg = Math.floor(Math.random() * (x - y)) + y;    
    
    var mainbox = document.getElementById('mainbox');
    mainbox.classList.remove('animate');

    document.getElementById('box').style.transform = "rotate("+deg+"deg)";


    var valueList = ["10","20","50","100","150","15","400","500"];

    for (var i = 0; i < valueList.length; i++){
        document.getElementById("arrPrint1").innerHTML =valueList[1];
        document.getElementById("arrPrint2").innerHTML =valueList[0];
        document.getElementById("arrPrint3").innerHTML =valueList[2];
        document.getElementById("arrPrint4").innerHTML =valueList[3];
        document.getElementById("arrPrint5").innerHTML =valueList[4];
        document.getElementById("arrPrint6").innerHTML =valueList[5];
        document.getElementById("arrPrint7").innerHTML =valueList[6];
        document.getElementById("arrPrint8").innerHTML =valueList[7];

    }
    
    
    setTimeout(function(){
        mainbox.classList.add('animate');

         
         var getValue = valueList[Math.floor(Math.random() * valueList.length)];
    },
        5000);
}


