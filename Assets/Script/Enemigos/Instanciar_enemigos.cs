using System.Collections;
using UnityEngine;


public class Instanciar_enemigos : MonoBehaviour,ISetGal
{
    /* factoria para instanciar enemigos al momento en que el player colisiona con
     box collider de la celda*/
    [SerializeField] GameObject[] _Enemigos,_Jefes;
    [SerializeField] Vector2 _offset;//offset para instanciar a los enemigos
    [SerializeField] bool _mostrar_jefe=false;
    [SerializeField] GameObject _VFX_Spawn_efect;
    [SerializeField] float _tiempo_delay = 1.0f; // Tiempo antes de que aparezca el enemigo
    Transform _transform;
    float _O_X, _O_Y;
    GameObject _Nuevo_enemigo;
    Game_manager _controler;
    int _num_gal = 0,
        _tot_gal=0;
    Vector3 _nn;
    bool _Activar_portal = false,
        _activar_enemigo=false;
    private void Update()
    {
        if (_Activar_portal)
        {
            Debug.Log(_tiempo_delay);
            _tiempo_delay -= Time.deltaTime;
        }
        if (_tiempo_delay <= 0 && _Activar_portal)
        {
            Debug.Log("activar variables activar enemigo y descativar portal");
            _activar_enemigo = true;
            _Activar_portal = false;
        }

        if (_activar_enemigo)
        {
            Debug.Log("llamada instanciar enemigo");
            instanciar_efectivo();
            _activar_enemigo = false;
        }
    }

    public void instanciar_enemigos()
    {
        _controler = Game_manager.Instance;
        _O_X = Random.Range(-_offset.x, _offset.x);
        _O_Y = Random.Range(-_offset.y, _offset.y);
        
        _transform = this.transform;
        //Vector3 spawnPos = _transform.position + new Vector3(_O_X, 0f, _O_Y);

        
        _nn = _transform.position + new Vector3(_O_X, 0f, _O_Y);
        GameObject vfx = Instantiate(_VFX_Spawn_efect, _nn, Quaternion.identity);
        Debug.Log("activar variable portal para inicair conteo");
        _Activar_portal = true;
        Destroy(vfx, 1.5f); // Cambiá 3f por la duración real del efecto si lo sabés
    }

    public void instanciar_efectivo()
    { 
        int t_en = Random.Range(0, _Enemigos.Length);
         if (_num_gal == 1 || _mostrar_jefe && !_controler._Jefe_activo)//si es la ultima galeria instancia el jefe una sola vez
        {
            Debug.Log("APARECE EL JEFE");
            _Nuevo_enemigo = Instantiate(_Jefes[0], _nn, Quaternion.identity);
            _controler.activar_jefe();
        }
        else
        {
            Debug.Log("instanciar enemigo");
            _Nuevo_enemigo = Instantiate(_Enemigos[t_en], _nn, Quaternion.identity);
        }
    }
    IEnumerator SpawnConEfecto(Vector3 posicion)
    {
        /*float tiempo = 0,
             duracion = _tiempo_delay;*/
        // Instanciar el efecto VFX
        GameObject vfx = Instantiate(_VFX_Spawn_efect, posicion, Quaternion.identity);
        Debug.Log("Se instancio el efecto portal");
        // Esperar un tiempo antes de instanciar el enemigo (mitad de la animación del VFX)
        Debug.Log("Esperando " + _tiempo_delay + " segundos...");
        //yield return new WaitForSeconds(_tiempo_delay);
        Debug.Log("Tiempo de espera terminado, instanciando enemigo...");

        // Instanciar el enemigo o jefe
        Debug.Log("variable jefe activo_" + _controler._Jefe_activo);
        if (_num_gal == 1 || (_mostrar_jefe && !_controler._Jefe_activo))
        {
            _Nuevo_enemigo = Instantiate(_Jefes[0], posicion, Quaternion.identity);
            _controler.activar_jefe();
        }
        else
        {
            Debug.Log("instanciando enemigo");
            int t_en = Random.Range(0, _Enemigos.Length);
            _Nuevo_enemigo = Instantiate(_Enemigos[t_en], posicion, Quaternion.identity);
        }

        // Opcional: destruir el efecto después de unos segundos
        Destroy(vfx, 1f); // Cambiá 3f por la duración real del efecto si lo sabés
        return null;
        
    }


    public void SetGal(int num, int tot)
    {
        //guardar datos de las galerias
        _tot_gal = tot;
        _num_gal = num;
    }
}
