import dotenv from "dotenv";

dotenv.config({path:"../../.env"});

// let: khai bao bien co the thay doi duoc
// const: khai bao hang so (khong the thay doi duoc)
// var: khong bao gio su dung
export const BASE_URL = process.env.BASE_URL;  // lay gia tri BASE_URL 

export const USERNAME_REQUIRED_MSG = "Username field is required. 🙁";
export const PWD_REQUIRED_MSG = "Password field is required. 🙁";
export const INVALID_CRE_MSG = "Invalid username or password. 😭"