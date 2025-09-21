import React, { useState } from 'react';

const RecuperarClave = () => {
    const [nuevaClave, setNuevaClave] = useState('');
    const [confirmarClave, setConfirmarClave] = useState('');
    const [token, setToken] = useState(new URLSearchParams(window.location.search).get('token'));
    const [usuario, setUsuario] = useState(new URLSearchParams(window.location.search).get('usuario'));
    const [mensaje, setMensaje] = useState('');

    const validarClave = (clave) => {
        return /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[^\s]{8,20}$/.test(clave);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (!validarClave(nuevaClave)) { setMensaje('Clave inválida'); return; }
        if (nuevaClave !== confirmarClave) { setMensaje('Las claves no coinciden'); return; }

        try {
            const res = await fetch('https://localhost:5001/api/RecuperarClave/cambiarClave', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    Token: token,
                    UserName: usuario,
                    NuevaClave: nuevaClave
                })
            });
            const data = await res.json();
            setMensaje(data.message || 'Contraseña cambiada correctamente');
        } catch (err) {
            setMensaje('Error: ' + err);
        }
    };

    return (
        <div>
            <h2>Recuperar Clave</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Nueva Clave</label>
                    <input type="password" value={nuevaClave} onChange={e => setNuevaClave(e.target.value)} />
                </div>
                <div>
                    <label>Confirmar Clave</label>
                    <input type="password" value={confirmarClave} onChange={e => setConfirmarClave(e.target.value)} />
                </div>
                <button type="submit">Confirmar Cambio</button>
            </form>
            <p>{mensaje}</p>
        </div>
    );
};

export default RecuperarClave;