import React, {useState} from 'react';
import MyInput from "../components/UI/input/MyInput";
import MyButton from "../components/UI/button/MyButton";
import {postVerificationSignature} from "../API/VerificationSignatureService";

const VerificationSignaturePage = () => {

    const [file, setFile] = useState();
    const [cert, setCert] = useState();
    const [sign, setSign] = useState();
    const [res, setRes] = useState("Нет");



    const uploadFile = (event) => {
        event.preventDefault();
        if (event.target.files[0]) {
            setFile(event.target.files[0]);
        }
    };

    const uploadCert = (event) => {
        event.preventDefault();
        if (event.target.files[0]) {
            setCert(event.target.files[0]);
        }
    };

    const uploadSign = (event) => {
        event.preventDefault();
        if (event.target.files[0]) {
            setSign(event.target.files[0]);
        }
    };

    const verificationSignature = async (e) => {
        e.preventDefault();

        const formData = new FormData();
        formData.append('file', file);
        formData.append('cert', cert);
        formData.append('sign', sign);

        const result = await postVerificationSignature(formData);

        if(result.data)
            setRes("Подпись прошла верификацию");
         else
            setRes("Подпись не прошла верификацию");
    }

    return (
        <div>
            <form>
                <h5>Файл</h5>
                <MyInput onChange={uploadFile} type="file" placeholder="Описание"/>
                <h5>Цифровая подпись</h5>
                <MyInput onChange={uploadSign} type="file" placeholder="Описание"/>
                <h5>Сертификат для проверки подписи</h5>
                <MyInput onChange={uploadCert} type="file" placeholder="Описание"/>

                <MyButton onClick={verificationSignature}>Проверить подпись</MyButton>
            </form>

            <h5>Результат</h5>
            <label>{res}</label>
       </div>
    );
};

export default VerificationSignaturePage;