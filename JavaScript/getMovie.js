document.addEventListener("DOMContentLoaded", (event) => {
    fetch("http://localhost:5117/api/movie", {
          method: "GET",
          headers: {
              "content-type": "application/json"
          },

      }).then(res => {
            
        if(res.ok) {

            
            
            res.json().then(text => {
                
                console.log(text)
               
                let cards = [document.getElementById("carouselAllMovies").getElementsByClassName("card")]

                cards.forEach(function(card){
                    console.log(card)
                    for (let i = 0; i < card.length; i++){
                        console.log(card[i].childNodes[3].childNodes)
                        card[i].childNodes[3].childNodes[1].textContent = text[i].title
                        card[i].childNodes[3].childNodes[3].textContent = `Overview: ${text[i].overview}`
                        card[i].childNodes[3].childNodes[5].textContent = `Popularity: ${text[i].vote_average}`
                        card[i].childNodes[3].childNodes[7].textContent = `Release Date: ${text[i].release_date}`
                        card[i].childNodes[3].childNodes[8].textContent = `Runtime: ${text[i].runtime} mins`
                    }
                });
            })
            
        } else{
       
            alert("Error")
        }
      })

      fetch("http://localhost:5117/api/movie/popularMovies", {
          method: "GET",
          headers: {
              "content-type": "application/json"
          },

      }).then(res => {
            
        if(res.ok) {

            
    
            res.json().then(text => {
                
                console.log(text[1])
               
                let cards = [document.getElementById("carouselPopularMovies").getElementsByClassName("card")]

                cards.forEach(function(card){
                    //console.log(card)
                    for (let i = 0; i < card.length; i++){
                        card[i].childNodes[3].childNodes[1].textContent = text[i].title
                        card[i].childNodes[3].childNodes[3].textContent = `Overview: ${text[i].overview}`
                        card[i].childNodes[3].childNodes[5].textContent = `Popularity: ${text[i].vote_average}`
                        card[i].childNodes[3].childNodes[7].textContent = `Release Date: ${text[i].release_date}`
                        card[i].childNodes[3].childNodes[8].textContent = `Runtime: ${text[i].runtime} mins`
                    }
                });
            })
            
        } else{
       
            alert("Error")
        }
      })

})


