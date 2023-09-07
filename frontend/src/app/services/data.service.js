import { getToken } from "../helpers/data.helper.js";
import { BASE_URL } from "../app.config.js";

class DataService {

    async getStudents() {
        const response = await fetch(`${BASE_URL}/Account?pageSize=50`,{
            method: "GET",
            mode: "cors",
            cache: "no-cache",
            credentials: "same-origin",
            headers:{
                "Authorization": `Bearer ${getToken()}`
            },
            redirect: "follow",
            referrerPolicy: "no-referrer"
        });
        const data = await response.json();
        const students = data.data.filter(user => user.type === 1);
        console.log(students);
        return students;
    }
}

export default new DataService();