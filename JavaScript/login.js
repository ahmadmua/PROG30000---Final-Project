
    document.getElementById("loginBtn")
    .addEventListener('click', () => {

        fetch("http://localhost:5117/api/account/login", {
            method: "POST",
            headers: {
                "content-type": "application/json"
            },
            body: JSON.stringify({
                email: document.getElementById("typeEmail").value,
                password: document.getElementById("typePassword").value,
            })

        }).then(res => {
            
            if(res.ok) {
                
                res.text().then(text => localStorage.setItem("Token", text))
                window.location.href = "../Views/browseMovies.html"
                function preventBack() { window.history.forward(); }  
                setTimeout(preventBack(), 0);  
                window.onunload = function () { null };  
                
            } else{
           
                alert("Incorrect email or password. Try again")
            }
          })
        
    })
