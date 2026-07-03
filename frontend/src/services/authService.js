import axiosClient from "../api/axiosClient";

export const login = async (email, password) => {
    const response = await axiosClient.post("/Auth/login", {
        email,
        password
    });

    return response.data;
};