document.addEventListener("DOMContentLoaded", (event) => {
    fetch("http://localhost:5117/api/shows", {
          method: "GET",
          headers: {
              "content-type": "application/json"
          },

      }).then(res => {
            
        if(res.ok) {

            
            
            res.json().then(text => {
                
                console.log(text)
               
                let cards = [document.getElementById("carouselAllShows").getElementsByClassName("card")]

                cards.forEach(function(card){
                    console.log(card)
                    for (let i = 0; i < card.length; i++){
                        console.log(card[i].childNodes[3].childNodes)
                        card[i].childNodes[3].childNodes[1].textContent = text[i].title
                        //card[i].childNodes[3].childNodes[3].textContent = text[i].overview
                    }
                });
            })
            
        } else{
       
            alert("Error")
        }
      })

      fetch("http://localhost:5117/api/shows/popularShows", {
          method: "GET",
          headers: {
              "content-type": "application/json"
          },

      }).then(res => {
            
        if(res.ok) {

            
    
            res.json().then(text => {
                
                console.log(text[1])
               
                let cards = [document.getElementById("carouselPopularShows").getElementsByClassName("card")]

                cards.forEach(function(card){
                    console.log(card)
                    for (let i = 0; i < card.length; i++){
                        console.log(card[i].childNodes[3].childNodes)
                        card[i].childNodes[3].childNodes[1].textContent = text[i].title
                        //card[i].childNodes[3].childNodes[3].textContent = text[i].overview
                    }
                });
            })
            
        } else{
       
            alert("Error")
        }
      })

})

