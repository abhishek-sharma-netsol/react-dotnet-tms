import { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

export default function Protected({ children, authentication = true }) {

    const navigate = useNavigate()
    const [loader, setLoader] = useState(true)
    const authStatus = localStorage.getItem("status");

    useEffect(() => {

        if (!authStatus) {
            navigate("/login")
        }

        setLoader(false)
    }, [authStatus, navigate, authentication])

    return (
        <div className="min-h-screen flex items-center justify-center">
            {loader ? (
                <div className="animate-spin rounded-full h-20 w-20 border-t-4 border-b-4 border-blue-500"></div>
            ) : (
                <>{children}</>
            )}
        </div>
    )
}
