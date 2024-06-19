import axios from "axios";

const backendUrl = process.env.REACT_APP_BACKEND_URL ?? 'https://localhost:7281';

const client = axios.create({
    baseURL: backendUrl
});

export {
    client
};

