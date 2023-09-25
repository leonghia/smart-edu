import dotenv from "dotenv";

dotenv.config({ path: "../../.env" });

// let: khai bao bien co the thay doi duoc
// const: khai bao hang so (khong the thay doi duoc)
// var: khong bao gio su dung
export const BASE_URL = process.env.BASE_URL;  // lay gia tri BASE_URL 

export const USERNAME_REQUIRED_MSG = "Username field is required. 🙁";
export const PWD_REQUIRED_MSG = "Password field is required. 🙁";
export const INVALID_CRE_MSG = "Invalid username or password. 😭";
export const USERNAME_LIMIT = "Username limit is from 3 to 30 characters. 😭";
export const PWD_LIMIT = "Password limit is from 6 to 64 characters. 😭";
export const DEFAULT_DOC_DES = "Douglas Hofstadter's book is concerned directly with the nature of “maps” or links between formal systems. However, according to Hofstadter, the formal system that underlies all mental activity transcends the system that supports it. If life can grow out of the formal chemical substrate of the cell, if consciousness can emerge out of a formal system of firing neurons, then so too will computers attain human intelligence. Gödel, Escher, Bach is a wonderful exploration of fascinating ideas at the heart of cognitive science: meaning, reduction, recursion, and much more."