import React, { useState, useEffect } from 'react';
import './RecuperarClave.css';
import { FaEye, FaEyeSlash } from 'react-icons/fa'; 

const RecuperarClave = () => {
    const [nuevaClave, setNuevaClave] = useState('');
    const [confirmarClave, setConfirmarClave] = useState('');
    const [mostrarNueva, setMostrarNueva] = useState(false);
    const [mostrarConfirmar, setMostrarConfirmar] = useState(false);
    const [token] = useState(new URLSearchParams(window.location.search).get('token'));
    const [usuario] = useState(new URLSearchParams(window.location.search).get('usuario'));
    const [mensaje, setMensaje] = useState('');
    const [mensajeTipo, setMensajeTipo] = useState('');

    useEffect(() => {
        document.title = 'CambiarClave';
        const link = document.createElement('link');
        link.rel = 'icon';
        link.href = '/IconNav.png';
        document.head.appendChild(link);
    }, []);

    const validarClave = (clave) => {
        const regex = /^(?=(?:.*[A-Z]){2,})(?=(?:.*[a-z]){2,})(?=(?:.*\d){2,}).{8,}$/;
        return regex.test(clave);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (!validarClave(nuevaClave)) {
            setMensaje('Clave invalida. Debe tener minimo 8 caracteres, 2 mayusculas, 2 minusculas y 2 numeros.');
            setMensajeTipo('error');
            return;
        }
        if (nuevaClave !== confirmarClave) {
            setMensaje('Las claves no coinciden.');
            setMensajeTipo('error');
            return;
        }

        try {
            const res = await fetch('https://localhost:7022/api/RecuperarClave/cambiarClave', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    userName: usuario,
                    token: token,
                    nuevaClave: nuevaClave
                })
            });

            if (!res.ok) {
                throw new Error("Error en la API: " + res.status);
            }

            const data = await res.json();
            setMensaje(data.message);
            setMensajeTipo('exito');
        } catch (err) {
            setMensaje('Error: ' + err);
            setMensajeTipo('error');
        }
    };

    return (
        <div className="container">
            <div className="card">
                <h2>Recuperar Clave</h2>
                <form onSubmit={handleSubmit}>
                    <div className="input-group">
                        <label>Nueva Clave</label>
                        <input
                            type={mostrarNueva ? "text" : "password"}
                            value={nuevaClave}
                            onChange={e => setNuevaClave(e.target.value)}
                        />
                        <span className="eye-icon" onClick={() => setMostrarNueva(!mostrarNueva)}>
                            {mostrarNueva == false ? <FaEyeSlash /> : <FaEye />}
                        </span>
                    </div>

                    <div className="input-group">
                        <label>Confirmar Clave</label>
                        <input
                            type={mostrarConfirmar ? "text" : "password"}
                            value={confirmarClave}
                            onChange={e => setConfirmarClave(e.target.value)}
                        />
                        <span className="eye-icon" onClick={() => setMostrarConfirmar(!mostrarConfirmar)}>
                            {mostrarConfirmar == false ? <FaEyeSlash /> : <FaEye />}
                        </span>
                    </div>
                    <button type="submit" className="btn-confirm">Confirmar Cambio</button>
                    {mensaje && (
                        <p className={`mensaje ${mensajeTipo === 'error' ? 'error' : 'exito'}`}>
                            {mensaje}
                        </p>
                    )}
                </form>
            </div>
        </div>
    );
};

export default RecuperarClave;
