document.addEventListener("DOMContentLoaded", (event) => {
    fetch("http://localhost:5117/api/shows", {
          method: "GET",
          headers: {
              "content-type": "application/json"
          },

      }).then(res => {
            
        if(res.ok) {

            
            
            res.json().then(text => {
                
                let cards = [document.getElementById("carouselAllShows").getElementsByClassName("card")]

                cards.forEach(function(card){
                    console.log(card)
                    for (let i = 0; i < card.length; i++){
                        //console.log(card[i].childNodes[3].childNodes)
                        card[i].childNodes[3].childNodes[1].textContent = text[i].title
                        card[i].childNodes[3].childNodes[3].textContent = `Overview: ${text[i].overview}`
                        card[i].childNodes[3].childNodes[5].textContent = `Popularity: ${text[i].vote_average}`
                        card[i].childNodes[3].childNodes[7].textContent = `Release Date: ${text[i].release_date}`
                        card[i].childNodes[3].childNodes[8].textContent = `Episodes: ${text[i].episodes}`
                        card[i].childNodes[3].childNodes[9].textContent = `Seasons: ${text[i].seasons}`
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
                
            
               
                let cards = [document.getElementById("carouselPopularShows").getElementsByClassName("card")]

                cards.forEach(function(card){
                    console.log(card)
                    for (let i = 0; i < card.length; i++){
                        //console.log(card[i].childNodes[3].childNodes)
                        card[i].childNodes[3].childNodes[1].textContent = text[i].title
                        card[i].childNodes[3].childNodes[3].textContent = `Overview: ${text[i].overview}`
                        card[i].childNodes[3].childNodes[5].textContent = `Popularity: ${text[i].vote_average}`
                        card[i].childNodes[3].childNodes[7].textContent = `Release Date: ${text[i].release_date}`
                        card[i].childNodes[3].childNodes[8].textContent = `Episodes: ${text[i].episodes}`
                        card[i].childNodes[3].childNodes[9].textContent = `Seasons: ${text[i].seasons}`
                    }
                });
            })
            
        } else{
       
            alert("Error")
        }
      })

})


