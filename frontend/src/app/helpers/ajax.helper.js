import { async } from "regenerator-runtime";
import { getToken } from "./token.helper";
import { HTTP_METHODS } from "../app.enum";

const handleError = function(message) {
    alert("Operation failed 😭: " + message);
}

export const getData = async function(url) {
    let res;
    try {
        const response = await fetch(url, {
            method: "GET",
            mode: "cors",
            cache: "no-cache",
            credentials: "same-origin",
            headers: {
                "Authorization": "Bearer " + getToken()
            },
            redirect: "follow",
            referrerPolicy: "no-referrer",
        });
        res = await response.json();
        if (!res.succeeded) {
            throw new Error(res.message);
        }
    } catch (err) {
        handleError(err.message);
    } finally {
        return res;
    }
}

export const postData = async function(url, data) {
    let res;
    try {
        const response = await fetch(url, {
            method: "POST",
            mode: "cors",
            cache: "no-cache",
            credentials: "same-origin",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + getToken()
            },
            redirect: "follow",
            referrerPolicy: "no-referrer",
            body: JSON.stringify(data),
        });
        res = await response.json();
        if (!res.succeeded) {
            throw new Error(res.message);
        }
    } catch (err) {
        handleError(err.message);
    } finally {
        return res;
    }
    
}

export const updateData = async function(url, data) {
    let res;
    try {
        const response = await fetch(url, {
            method: "PUT",
            mode: "cors",
            cache: "no-cache",
            credentials: "same-origin",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + getToken()
            },
            redirect: "follow",
            referrerPolicy: "no-referrer",
            body: JSON.stringify(data),
        });
        res = await response.json();
        if (!res.succeeded) {
            throw new Error(res.message);
        }
    } catch (err) {
        handleError(err.message);
    } finally {
        return res;
    }
    
}

export const deleteData = async function(url) {
    let res;
    try {
        const response = await fetch(url, {
            method: "DELETE",
            mode: "cors",
            cache: "no-cache",
            credentials: "same-origin",
            headers: {
                "Authorization": "Bearer " + getToken()
            },
            redirect: "follow",
            referrerPolicy: "no-referrer",
        });
        res = await response.json();
        if (!res.succeeded) {
            throw new Error(res.message);
        }
    } catch (err) {
        handleError(err.message);
    } finally {
        return res;
    } 
}