import { async } from "regenerator-runtime";
import authService from "../services/auth.service.js";

export const login = async function (url = "", dataDTO = {}) {
  const response = await fetch(url, {
    method: "POST", //cho phep truyen du lieu den sever
    mode: "cors",
    cache: "no-cache",
    credentials: "same-origin",
    headers: {
      "Content-Type": "application/json",
    },
    redirect: "follow",
    referrerPolicy: "no-referrer",
    body: JSON.stringify(dataDTO),
  });
  return await response.json();
};

export const getData = async function (url = "") {
  const response = await fetch(url, {
    method: "GET",
    mode: "cors",
    cache: "no-cache",
    credentials: "same-origin",
    headers: {
      Authorization: `Bearer ${authService._token}`,
    },
    redirect: "follow",
    referrerPolicy: "no-referrer",
  });

  return await response.json();
};
