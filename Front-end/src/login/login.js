import "./login.css";
import { useRef, useState, useEffect, useContext } from "react";
import AuthContext from "./AuthProvider";
import frame from "../img/frame1.png";
import React from "react";
import { ReactComponent as Account } from "../img/account.svg";
import { ReactComponent as Account_1 } from "../img/account_1.svg";
import Logo from "../img/LogoSanPatrick.png";
import axios from "./axios";

  function cuentaSeleccionada(e){
    e.preventDefault();
  }

  const LOGIN_URL = "api/v1/auth";

const Login = () => {
  const { setAuth } = useContext(AuthContext);
  const userRef = useRef();
  const errRef = useRef();

  const [CardNumber, setCard] = useState("");
  const [Pin, setPin] = useState("");
  const [errMsg, setErrMsg] = useState("");
  const [sucess, setSucess] = useState("");



  useEffect(() => {
    userRef.current.focus();
  }, []);

  useEffect(() => {
    setErrMsg("");
  }, [CardNumber, Pin]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post(
        LOGIN_URL,
        JSON.stringify({ CardNumber, Pin }),
        { headers: { "Content-Type": "application/json" } }
      );
      console.log(response?.data);
      const accessToken = response?.data?.Token;
      setAuth({ CardNumber, Pin, accessToken });
      setCard("");
      setPin("");
      setSucess(true);
    } catch (err) {
      if (!err.response) {
        setErrMsg("No server response");
      } else if (err.response?.status === 400) {
        setErrMsg("Missing Card number or Password");
      } else if (err.response?.status === 401) {
        setErrMsg("Unatorized");
      } else if (err.response?.status === 502) {
        setErrMsg("Bad Gateway");
      } else {
        setErrMsg("Login Failed");
      }
      errRef.current.focus();
    }
  };

  return (
    <>
      {sucess ? (
        <section>
          <p
            ref={errRef}
            className={errMsg ? "errmsg" : "offscreen"}
            aria-live="assertive"
          >
            {errMsg}
          </p>
          <h1>Te has logeado</h1>
          <p>
            <a href="#">HomeBanking</a>
          </p>
        </section>
      ) : (
        <div className="general">
          <div className="container">
          <div className="wrapper">
          <div className="img division">
            <img src={frame} />
          </div>
          <div className="cardlogin division">
            <div className="logoMasTitulo">
              <img src={Logo} />
              <h1 className="titulo"><span className="primeraLinea">Banco</span><span className="segundaLinea"> San Patrick</span></h1>
            </div>
            <div className="list-container">
              <ul className="lists">
                <li>
                  <a href="#" className="tipo-ingr" onClick={cuentaSeleccionada}>
                    <Account className="iconosCuentas" />
                    <span className="botonCardLogin">Personal</span>
                  </a>
                </li>
                <li>
                  <a href="#" className="tipo-ingr" onClick={cuentaSeleccionada}>
                    <Account_1 className="iconosCuentas" />
                    <span className="botonCardLogin">Empresarial</span>
                  </a>
                </li>
              </ul>
            </div>
            <div className="formulario" onSubmit={handleSubmit}>
              <form>
                <div>
                  <label >Nombre de usuario</label >
                </div>
                <input 
                  type="text"
                  id="CardNumber"
                  ref={userRef}
                  autoComplete="off"
                  onChange={(e) => setCard(e.target.value)}
                  value={CardNumber}
                />
                <div>
                  <label >Contraseña</label>
                </div>
                <input 
                  type="password"
                  id="Pin"
                  onChange={(e) => setPin(e.target.value)}
                  value={Pin}
                />
                <div className="recuperar">
                  <a href="#">¿Olvidaste tu contraseña?</a>
                </div>
                <button className="btn-acceder">Acceder</button>
                <div className="sombra"></div>
              </form>
              <div>
              </div>
            </div>
          </div>
          </div>
        </div>
        </div>
      )}
    </>
  );
};

export default Login;
