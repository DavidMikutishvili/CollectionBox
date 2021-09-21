import axios from "axios";

const API_URL = "https://localhost:44315/api/Authenticate/";
class AuthService {
  login(username: string, password: string) {
    console.log(username)
    return axios
      .post(API_URL + "login", {
        username,
        password
      })
      .then(response => {
        if (response.data.accessToken) {
          localStorage.setItem("user", JSON.stringify(response.data));
        }

        return response.data;
      });
  }

  logout() {
    localStorage.removeItem("user");
  }

  register(name: string, email: string, password: string) {
    console.log(name);
    return axios.post(API_URL + "register", {
      name,
      email,
      password
    });
  }

  getCurrentUser() {
    const userStr = localStorage.getItem("user");
    if (userStr) return JSON.parse(userStr);

    return null;
  }
}

export default new AuthService();