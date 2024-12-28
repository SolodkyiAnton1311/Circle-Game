public abstract class Controller
{
    protected View _view;
   protected Model _model;

    public Controller(View view, Model model)
    {
        _view = view;
        _model = model;
       
    }
}
