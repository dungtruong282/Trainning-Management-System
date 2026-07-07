import { useEffect, useState } from "react";
import MainLayout from "../../components/layout/MainLayout";
import { getUsers } from "../../services/userService";

export default function Users() {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        getUsers()
            .then((data) => {
                console.log(data);
                setUsers(data);
            })
            .catch((error) => {
                console.log(error);
            });
    }, []);

    return (
        <MainLayout>
            <h1>Users Management</h1>

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
                            <th>Full Name</th>
                            <th>Email</th>
                            <th>Role</th>
                            <th>Department</th>
                        </tr>
                    </thead>

                    <tbody>
                        {users.map((user) => (
                            <tr key={user.id}>
                                <td>{user.id}</td>
                                <td>{user.fullName}</td>
                                <td>{user.email}</td>
                                <td>{user.role}</td>
                                <td>{user.departmentName}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </MainLayout>
    );
}