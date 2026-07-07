import { useEffect, useState } from "react";
import MainLayout from "../../components/layout/MainLayout";
import { getDepartments } from "../../services/departmentService";

export default function Departments() {
    const [departments, setDepartments] = useState([]);

    useEffect(() => {
        getDepartments()
            .then(setDepartments)
            .catch((error) => console.log(error));
    }, []);

    return (
        <MainLayout>
            <h1>Departments Management</h1>

            <div style={{
                background: "white",
                padding: "20px",
                borderRadius: "12px"
            }}>
                <table style={{
                    width: "100%",
                    borderCollapse: "collapse"
                }}>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Name</th>
                            <th>Description</th>
                            <th>Created At</th>
                        </tr>
                    </thead>

                    <tbody>
                        {departments.map((department) => (
                            <tr key={department.id}>
                                <td>{department.id}</td>
                                <td>{department.name}</td>
                                <td>{department.description}</td>
                                <td>{new Date(department.createdAt).toLocaleDateString()}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </MainLayout>
    );
}