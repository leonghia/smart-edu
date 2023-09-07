import dotenv from "dotenv";

dotenv.config({path:"../../.env"});

// let: khai bao bien co the thay doi duoc
// const: khai bao hang so (khong the thay doi duoc)
// var: khong bao gio su dung
export const BASE_URL = process.env.BASE_URL;  // lay gia tri BASE_URL 