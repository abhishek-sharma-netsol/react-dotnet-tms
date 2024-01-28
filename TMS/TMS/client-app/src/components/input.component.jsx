import { forwardRef, useId } from 'react'

const Input = forwardRef(
    function Input({ label, type = "text", className = "", ...props }, ref) {

        const id = useId();

        return (
            <div className='mb-4'>
                {label &&
                    <label className='block text-sm font-bold mb-2' htmlFor={id}>
                        {label}
                    </label>
                }

                <input type={type}
                    className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 
                    leading-tight focus:outline-none focus:shadow-outline ${className}`}
                    ref={ref} id={id} {...props}
                />
            </div>
        )
    })

export default Input;