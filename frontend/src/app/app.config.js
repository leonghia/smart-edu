import dotenv from "dotenv";

const result = dotenv.config({ path: "../../.env" });

export const { BASE_URL } = process.env;
