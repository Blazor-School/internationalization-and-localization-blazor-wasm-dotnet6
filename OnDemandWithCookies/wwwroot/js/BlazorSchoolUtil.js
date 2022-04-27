class BlazorSchoolUtil
{
    updateCookies(key, value)
    {
        document.cookie = `${key}=${value}`;
    }
}

window.BlazorSchoolUtil = new BlazorSchoolUtil();