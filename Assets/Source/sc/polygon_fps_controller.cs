using UnityEngine;

public class polygon_fps_controller : MonoBehaviour
{

   

    public float vertical_float_spread;
    public float horizontal_float_spread;

 
/// ////////////////////////////////////////////////////////////////////////
    private void LateUpdate()
    {
        
        aimming();
    }

    public GameObject DHAR;

    public float min_angle;
    public float max_angle;

    public float VS;
    public float HS;

    public float saved_roation_X;

    public void aimming()
    {

        float Xm = Input.GetAxis("Mouse X");
        float Ym = Input.GetAxis("Mouse Y");
      



        // adding recoil movement to the aim

        float add_hor = horizontal_float_spread;
        horizontal_float_spread = 0;


      
        vertical_float_spread = 0;




      transform.eulerAngles = new Vector3(transform.eulerAngles.x, (transform.eulerAngles.y + add_hor) + Xm  * Time.deltaTime * HS, transform.eulerAngles.z);



        Vector3 rot = new Vector3((saved_roation_X) - Ym * Time.deltaTime * VS,transform.eulerAngles.y, DHAR.transform.eulerAngles.z*0);

        // limit of rotation for the aimming
        rot.x = Mathf.Clamp(rot.x, min_angle, max_angle);


        // Here gets the current roation value saved to reuse it, that we don't begin at zero, because the animation overplays all
        saved_roation_X = rot.x;



        DHAR.transform.eulerAngles = rot;
        ///////////////////////////////////

    }


}
