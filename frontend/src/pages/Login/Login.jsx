import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { login } from "../../services/authService";

export default function Login() {
    const navigate = useNavigate();

    const [email, setEmail] = useState("dungjwt@gmail.com");
    const [password, setPassword] = useState("123456");
    const [message, setMessage] = useState("");

    const handleLogin = async (event) => {
        event.preventDefault();

        try {
            const data = await login(email, password);

            localStorage.setItem("token", data.token);
            localStorage.setItem("fullName", data.fullName);
            localStorage.setItem("role", data.role);

            navigate("/dashboard");
        } catch (error) {
            console.log(error);
            setMessage("Login failed. Please check your email or password.");
        }
    };

    return (
        <div style={styles.container}>
            <form style={styles.card} onSubmit={handleLogin}>
                <h2 style={styles.title}>Training Management System</h2>

                <input
                    type="email"
                    placeholder="Email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    style={styles.input}
                />

                <input
                    type="password"
                    placeholder="Password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    style={styles.input}
                />

                <button type="submit" style={styles.button}>
                    Login
                </button>

                {message && <p style={styles.error}>{message}</p>}
            </form>
        </div>
    );
}

const styles = {
    container: {
        height: "100vh",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        background: "#f4f6f8"
    },
    card: {
        width: "380px",
        padding: "32px",
        background: "white",
        borderRadius: "12px",
        boxShadow: "0 4px 20px rgba(0,0,0,0.1)"
    },
    title: {
        textAlign: "center",
        marginBottom: "24px"
    },
    input: {
        width: "100%",
        boxSizing: "border-box",
        padding: "12px",
        marginBottom: "14px",
        border: "1px solid #d1d5db",
        borderRadius: "8px"
    },
    button: {
        width: "100%",
        padding: "12px",
        background: "#2563eb",
        color: "white",
        border: "none",
        borderRadius: "8px",
        cursor: "pointer"
    },
    error: {
        color: "#dc2626",
        textAlign: "center",
        marginTop: "14px"
    }
};
