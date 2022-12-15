window.onload = function(){

      fetch("http://localhost:5117/api/account/username", {
          method: "GET",
          headers: {
              "content-type": "application/json",
              'Authorization': `Bearer ${localStorage.getItem("Token")}`
          },

      }).then(res => {
            
        if(res.ok) {
            
            res.text().then(text => {
                
                document.getElementById("loggedInUserName").append(text)

            })
            
        } else{
       
            alert("Error")
        }
      })
    


}