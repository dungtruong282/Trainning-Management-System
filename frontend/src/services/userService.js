import axiosClient from "../api/axiosClient";

export const getUsers = async () => {
    const response = await axiosClient.get("/Users");
    return response.data;
};