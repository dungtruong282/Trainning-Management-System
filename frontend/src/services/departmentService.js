import axiosClient from "../api/axiosClient";

export const getDepartments = async () => {
    const response = await axiosClient.get("/Departments");
    return response.data;
};