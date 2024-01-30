const Modal = ({ children, title, isOpen, onClose }) => {
    return (
        <div
            className={`fixed z-2 inset-0 flex items-center justify-center ${isOpen ? 'block' : 'hidden'}`}
            aria-labelledby="modal-title" role="dialog" aria-modal="true"
        >
            <div className="fixed inset-0 bg-black opacity-50"></div>
            <div className="relative max-w-md w-full bg-white shadow-xl rounded-lg p-4"
                onClick={(e) => e.stopPropagation()}>
                <div className="absolute top-0 right-0 pt-3 pr-4">
                    <button
                        type="button"
                        className="bg-transparent text-2xl font-semibold text-gray-400 hover:text-gray-500 
                        focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
                        onClick={onClose}
                    >
                        ×
                    </button>
                </div>
                <h3 className="text-xl font-semibold text-center text-gray-900 mb-3">
                    {title}
                </h3>
                {children}
            </div>
        </div>
    );
};

export default Modal;