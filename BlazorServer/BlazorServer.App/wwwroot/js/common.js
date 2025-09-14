window.ShowToastr = (type, message) => {
    // Toastr don't work with Bootstrap 4.2
    toastr.options.toastClass = "toastr"; // https://github.com/CodeSeven/toastr/issues/599

    if (type === "success") {
        toastr.success(message, "Operation Successful", { timeOut: 20000 });
    }
    if (type === "error") {
        toastr.error(message, "Operation Failed", { timeOut: 20000 });
    }
};
