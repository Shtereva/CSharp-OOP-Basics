using System.Collections.Generic;

interface ILeutenantGeneral : IPrivate
{
    List<PrivateGeneral> Privates { get; set; }

    void AddPrivate(PrivateGeneral @private);
}
