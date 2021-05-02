    function getDataFromJSON(allText){
        
        const json = allText;
        const jsonParsed = JSON.parse(json);
        
        
        var humidity = jsonParsed.data.humidity;
        var temperature = jsonParsed.data.temperature;
        
        
        var data = [humidity, temperature];
        return data;
    }
    
    function readData(){
        var espFile = new XMLHttpRequest();
        var espUrl = "\data.json"
        
        var data = null;
        espFile.onreadystatechange = function(){
            if(espFile.readyState === 4){               
                if(espFile.status === 200 || espFile == 0){                   
                    var allText = espFile.responseText;                    
                    data = getDataFromJSON(allText);
                }
            }
        }
        
        espFile.open("GET", espUrl, false);
        espFile.send(null);
        return data;
    }
    
    
    
    function updateMainSite(){
        var data = readData();

        if(data == null){
            document.getElementById("humidity").innerHTML = "No data";
            document.getElementById("temperature").innerHTML = "No data";
        }else{
            document.getElementById("humidity").innerHTML = data[0];
            document.getElementById("temperature").innerHTML = data[1];
        }
   
        var d = new Date();
        document.getElementById("time").innerHTML = d.getHours() + ":"
            + d.getMinutes() + ":" + d.getSeconds();
    }

   
   
    window.setInterval(updateMainSite, 500);
