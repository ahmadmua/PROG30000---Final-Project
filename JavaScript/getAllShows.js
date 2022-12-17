document.addEventListener("DOMContentLoaded", (event) => {
    fetch("http://localhost:5117/api/shows", {
          method: "GET",
          headers: {
              "content-type": "application/json"
          },

      }).then(res => {
            
        if(res.ok) {
            
            res.text().then(text => {
                
                console.log(text)

            })
            
        } else{
       
            alert("Error")
        }
      })
})