  const btns = document.querySelectorAll("button");
  for (let i = 0; i < btns.length; i++) {
    const element = btns[i];
    element.addEventListener("click",(eevent) => {
    eevent.preventDefault();
    const fname = document.querySelector("#fname").value;
    const lname = document.querySelector("#lname").value;
    const gender = document.querySelector("#gender").value;
    const kannada= document.querySelector("#kannada").value;
    const english= document.querySelector("#english").value;
    const hindi= document.querySelector("#hindi").value;
   // const sum = kannada + english;
 /*   const a = 1;
    const b = 2;
    const sum = a + b;
    var Total = [];
    for( var i = 0; i < english.length; i++)
{
    Total.push(english[i]+hindi[i]);
}  */
 //   console.log(fname,lname,gender,kannada,english,hindi, sum);
   // console.log( );

    const empList = document.querySelector(".employee-list");
    empList.innerHTML += `
         <div class="employee-list-item">
          <div class="employee-name">NAME: ${fname} ${lname}</div>
          <div class="employee-name"></div>
          <div class="employee-detail">
          <div>GENDER: ${gender}</div>
          <div>Kannada marks: ${kannada}</div>
          <div>English marks: ${english}</div>
          <div>Hindi marks: ${hindi} + ${english}</div>
        
          </div>
        </div>`;
    document.querySelectorAll("input").forEach(e => { 
        e.value = "";
        });
  });
}