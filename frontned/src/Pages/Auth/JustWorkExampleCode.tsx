export function authUser(UserName: string, UserPassword: string) {
    fetch("http://localhost:5148/api/auth", {
        method: "post",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            UserName: UserName,
            password: UserPassword
        })
    })
        .then((response) => {
            response.json();
        });
}