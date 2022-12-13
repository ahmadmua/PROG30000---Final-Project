
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
              
                window.location.href = "../Views/index.html"
           
            } else{
           
                alert("Incorrect email or password. Try again")
            }
          })
        
    })
