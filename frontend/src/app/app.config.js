import dotenv from "dotenv";

const result = dotenv.config({path: "../../.env"});

export const { BASE_URL } = process.env; // const BASE_URL = process.env.BASE_URL;