import { getToken } from "../helpers/token.helper.js";
import { BASE_URL } from "../app.config.js";

class DataService {

    async getStudents() {
        const response = await fetch(`${BASE_URL}/Student`,{
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
        return await response.json();
    }

    async getMainClasses() {
        const response = await fetch(`${BASE_URL}/MainClass`,{
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
        return await response.json();
    }
}

export default new DataService();